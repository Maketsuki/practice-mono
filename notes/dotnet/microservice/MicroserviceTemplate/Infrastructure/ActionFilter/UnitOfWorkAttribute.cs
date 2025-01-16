using MicroserviceTemplate.Controllers;
using MicroserviceTemplate.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceTemplate.Infrastructure.ActionFilters
{
    public class UnitOfWorkAttribute : ActionFilterAttribute, IAsyncActionFilter
    {
        private readonly MicroserviceTemplateDbContext _dbContext;

        public UnitOfWorkAttribute(MicroserviceTemplateDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            ActionExecutedContext result = await next();

            try
            {
                // Check if there exists an open transaction
                if (_dbContext.Database.CurrentTransaction != null)
                {
                    // All Controllers are inherited from BaseApiController
                    BaseApiController controller = (BaseApiController)context.Controller;

                    // If errors have occurred while handling the request, don't try to save changes to the database because they have to be rolled back anyway
                    if (controller.DoRollback || controller.HasModelValidationError || result.Exception != null)
                    {
                        DoRollback(result, controller, _dbContext);
                    }
                    else
                    {
                        bool changesSaved = true;

                        if (_dbContext.ChangeTracker.HasChanges())
                        {
                            changesSaved = await _dbContext.SaveChangesAsync() > 0;
                        }

                        // Check if we should do a Commit or a Rollback
                        if (!changesSaved)
                        {
                            DoRollback(result, controller, _dbContext);
                        }
                        else
                        {
                            try
                            {
                                _dbContext.Database.CurrentTransaction.Commit();
                            }
                            catch (Exception)
                            {
                                _dbContext.Database.CurrentTransaction?.Rollback();

                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                result.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            }
        }

        /// <summary>
        /// Rollback all changes and set status code of the response to publicServerError if it hasn't been set yet.
        /// </summary>
        /// <param name="actionExecutedContext">HttpActionExecutedContext</param>
        /// <param name="controller">BaseApiController</param>
        /// <param name="dbContext">PlanningDbContext</param>
        private static void DoRollback(ActionExecutedContext actionExecutedContext, BaseApiController controller, MicroserviceTemplateDbContext dbContext)
        {
            dbContext.Database.CurrentTransaction.Rollback();

            // If ModelState has errors, don't set StatusCode here because it has been already set in ModelValidationAttribute.
            if (actionExecutedContext.HttpContext.Response != null
                && actionExecutedContext.HttpContext.Response.StatusCode != (int)System.Net.HttpStatusCode.Unauthorized
                && (!controller.HasModelValidationError || actionExecutedContext.HttpContext.Response.StatusCode == (int)System.Net.HttpStatusCode.OK))
            {
                actionExecutedContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            }
        }
    }
}
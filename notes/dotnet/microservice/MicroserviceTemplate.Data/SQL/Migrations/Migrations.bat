echo: & echo Starting database migrations... & echo: & E:\flyway-commandline-5.0.7-windows-x64\flyway-5.0.7\flyway -url=jdbc:postgresql://localhost/template-database -user=microservice-template-admin -password=Asdf!234 -outOfOrder=true -ignoreMissingMigrations=true -locations=filesystem:"./" migrate && echo: & echo Database migrated successfully
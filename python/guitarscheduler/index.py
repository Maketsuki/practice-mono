import datetime

# Global Variables
global_weekday = datetime.datetime.today().weekday()

def print_globals():
    today = datetime.datetime.today()
    weekday_name = today.strftime("%A")
    print(f"Weekday number: {global_weekday}")
    print(f"Weekday name: {weekday_name}")

print_globals()
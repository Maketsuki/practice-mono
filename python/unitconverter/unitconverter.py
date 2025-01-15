def convert_from_meters(meters):
    conversions = {
        "Kilometers": meters / 1000,
        "Centimeters": meters * 100,
        "Millimeters": meters * 1000,
        "Inches": meters * 39.3701,
        "Feet": meters * 3.28084,
        "Yards": meters * 1.09361,
        "Miles": meters / 1609.34,
        "Nautical miles": meters / 1852,
    }

    print(f"Conversion for {meters} meters:")
    for unit, value in conversions.items():
        print(f"{value:.4f}: {unit}")

if __name__ == "__main__":
    try:
        meters = float(input("Enter the length in meters: "))
        if meters < 0:
            print("Please enter a non-negative value")
        else:
            convert_from_meters(meters)
    except ValueError:
        print("Please enter a valid number")
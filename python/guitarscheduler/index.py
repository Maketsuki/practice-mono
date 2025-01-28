import time
import random


# Guitar Practice Routine Scheduler
# TODO: Add explanations for each practice routine choice
# TODO: Add more practice routine choices
# TODO: Add a Skip/Stop option
# TODO: Multiple choices for each practice routine part, pick from 3 etc. 


# Practice routine choices
warm_ups = [
    "Basic Chromatic Drill",
    "Spider Exercise",
    "Stretch & Strum",
    "Fingerstyle Arpeggio Pattern",
    "Legato Warm-Up"
]

techniques = [
    "Practice Scales & Modes",
    "Chord Drill (maj/min/7th)",
    "String Skipping & Alternate Picking",
    "Bending & Vibrato",
    "Fingerstyle Independence"
]

repertoire = [
    "Focus on 1 Song Section",
    "Riff or Solo Breakdown",
    "Multiple Short Excerpts",
    "Classical Piece Reading",
    "Style Adaptation"
]

ear_training_creativity = [
    "Interval Recognition",
    "Chord Progression by Ear",
    "Sing & Play",
    "Short Improvisation",
    "Call and Response"
]


def countdown(minutes):
    seconds_left = minutes * 60
    while seconds_left > 0:
        min_left = seconds_left // 60
        sec_left = seconds_left % 60
        print(f"Time remaining: {min_left:02d}:{sec_left:02d}", end="\r")
        time.sleep(1)
        seconds_left -= 1
    print("\nTime is up!\n")


def main():
    print("Welcome to your Guitar Practice Routine!\n")

    daily_warmup = random.choice(warm_ups)
    daily_technique = random.choice(techniques)
    daily_repertoire = random.choice(repertoire)
    daily_ear_creativity = random.choice(ear_training_creativity)

    warmup_minutes = 5
    technique_minutes = 10
    repertoire_minutes = 10
    ear_minutes = 5

    print(f"Warm-Up: {daily_warmup}")
    input("Press Enter to start the timer for Warm-Up...")
    countdown(warmup_minutes)

    print(f"Technique: {daily_technique}")
    input("Press Enter to start the timer for Technique...")
    countdown(technique_minutes)

    print(f"Repertoire: {daily_repertoire}")
    input("Press Enter to start the timer for Repertoire...")
    countdown(repertoire_minutes)

    print(f"Ear Training & Creativity: {daily_ear_creativity}")
    input("Press Enter to start the timer for Ear Training & Creativity...")
    countdown(ear_minutes)

    print("Practice session complete! Great job today.")

if __name__ == "__main__":
    main()
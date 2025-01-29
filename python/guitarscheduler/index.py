import time
import random
import threading
import queue


# Guitar Practice Routine Scheduler
# TODO: Add explanations for each practice routine choice DONE
# TODO: Add more practice routine choices
# TODO: Add a Skip/Stop option
# TODO: Multiple choices for each practice routine part, pick from 3 etc. 
# TODO: Add a way to track progress
# TODO: Add probability functionality for each practice routine part (don't get the same thing every time)
# TODO: Add a progress bar for each practice routine part and color output
# TODO: Different routine for acoustic or electric guitar
# TODO: Metronome


# Bugs:
# Stopping will not stop the program
# Difficult to tell when you can write skip or stop


# Practice routine choices
warm_ups = {
    "Basic Chromatic Drill": " \n* Move finger combinations (1-2-3-4) across each string. \n* Focus on clean, even picking or fingerstyle strokes.",
    "Spider Exercise": "\n* Use variations like 1-3-2-4 on each string to develop finger independence.\n* Move it slowly up and down the neck. ",
    "Stretch & Strum": "\n* Start with gentle stretches for your hands and wrists.\n* Practice basic open chords (G–C–D–E–A) with slow, controlled strums.",
    "Fingerstyle Arpeggio Pattern": "\n* Use p-i-m-a on open strings (for nylon or steel-string acoustic).\n* Gradually increase speed, ensuring even volume.",
    "Legato Warm-Up": "\n* Pick an easy scale (e.g., C major) and practice hammer-ons and pull-offs.\n* Keep the picking hand relaxed and the fretting hand movements smooth."
}

techniques = {
    "Practice Scales & Modes": "\n* Pick a scale (major, minor, pentatonic) and practice with a metronome.\n* Increase speed gradually; focus on consistent tone production.",
    "Chord Drill (maj/min/7th)": "\n* Work on smooth transitions between chord shapes (majors, minors, 7ths).\n* Practice strumming patterns or arpeggiating each chord.",
    "String Skipping & Alternate Picking": "\n* Choose a scale or short sequence and deliberately skip strings in between notes.\n* This builds coordination and picking accuracy.",
    "Bending & Vibrato": "\n* Practice half-step, whole-step, and micro bends; check pitch by comparing to the target note.\n* Add vibrato to held notes for added expression.",
    "Fingerstyle Independence": "\n* If you’re focusing on classical or fingerstyle, practice “p-i-m-a” patterns on different chord shapes.\n* Alternate bass notes, maintain a steady rhythm, and pay attention to tone."
}

repertoire = {
    "Focus on 1 Song Section": "\n* Select one piece and work on small sections that you find challenging.\n* Use a metronome or slow backing track, gradually building up tempo.",
    "Riff or Solo Breakdown": "\n* Take a famous riff or short solo you love; isolate tricky licks and practice them repeatedly.\n* Ensure accuracy before speed.",
    "Multiple Short Excerpts": "\n* Pick 2–3 short excerpts from different songs (could be classical, pop, rock).\n* Spend a few minutes on each, focusing on specific techniques or tricky bars.",
    "Classical Piece Reading": "\n* If you read music or tabs, practice a short classical piece on nylon strings.\n* Emphasize proper finger placement and dynamics.",
    "Style Adaptation": "\n* Take a simple tune (folk, rock, pop) and adapt it to a different style (e.g., fingerstyle, jazz chords).\n* This encourages creativity and stylistic flexibility."
}

ear_training_creativity = {
    "Interval Recognition": "\n* Play or sing intervals, then identify or reproduce them on the guitar.\n* Start with simple intervals (major 2nd, perfect 5th) and expand as you improve.",
    "Chord Progression by Ear": "\n* Listen to a short progression (I–IV–V, etc.).\n* Try to identify each chord and replicate it on guitar.",
    "Sing & Play": "\n* Sing a short melody, then find it on the fretboard.\n* Helps connect your ear to your fingers.",
    "Short Improvisation": "\n* Use the scale of the day and jam over a backing track or loop.\n* Keep it simple; focus on phrasing and melodic sense.",
    "Call and Response": "\n* Record yourself playing a short phrase.\n* Try to “answer” that phrase with a new idea that complements the first."
}

# This holds user commands
command_queue = queue.Queue()

def user_input_listener():
    while True:
        user_input = input().strip().lower()
        command_queue.put(user_input)


def countdown(minutes):
    seconds_left = minutes * 60
    while seconds_left > 0:

        if not command_queue.empty():
            command = command_queue.get()
            if command == "stop":
                print("\nPractice session stopped.")
                return 'stopped'
            elif command == "skip":
                print("\nPractice section skipped.")
                return 'skipped'

        min_left = seconds_left // 60
        sec_left = seconds_left % 60
        print(f"Time remaining: {min_left:02d}:{sec_left:02d}", end="\r")
        time.sleep(1)
        seconds_left -= 1
    print("\nTime is up!\n")
    return 'done'


def main():
    print("Welcome to your Guitar Practice Routine!\n")
    print("Type 'skip' to skip the current section or 'stop' to end the entire session at any time.\n")

    listener_thread = threading.Thread(target=user_input_listener, daemon=True)
    listener_thread.start()

    daily_warmup_key = random.choice(list(warm_ups.keys()))
    daily_technique_key = random.choice(list(techniques.keys()))
    daily_repertoire_key = random.choice(list(repertoire.keys()))
    daily_ear_creativity_key = random.choice(list(ear_training_creativity.keys()))

    warmup_minutes = 5
    technique_minutes = 10
    repertoire_minutes = 10
    ear_minutes = 5

    print(f"Warm-Up: {daily_warmup_key} {warm_ups[daily_warmup_key]}")
    input("Press Enter to start the timer for Warm-Up...")
    result = countdown(warmup_minutes)
    if result == 'stopped':
        return  # End entire session immediately

    print(f"Technique: {daily_technique_key} {techniques[daily_technique_key]}")
    input("Press Enter to start the timer for Technique...")
    countdown(technique_minutes)
    if result == 'stopped':
        return  # End entire session immediately

    print(f"Repertoire: {daily_repertoire_key} {repertoire[daily_repertoire_key]}")
    input("Press Enter to start the timer for Repertoire...")
    countdown(repertoire_minutes)
    if result == 'stopped':
        return  # End entire session immediately

    print(f"Ear Training & Creativity: {daily_ear_creativity_key} {ear_training_creativity[daily_ear_creativity_key]}")
    input("Press Enter to start the timer for Ear Training & Creativity...")
    countdown(ear_minutes)
    if result == 'stopped':
        return  # End entire session immediately

    print("Practice session complete! Great job today.")

if __name__ == "__main__":
    main()
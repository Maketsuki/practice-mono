import time
import winsound

def metronome(bpm=120, beats=4):
    # Duration between beats in seconds
    delay = 60 / bpm

    for i in range(beats):
        # frequency = 440 Hz (A), duration = 100 milliseconds
        winsound.Beep(440, 550)
        time.sleep(delay - 0.1)  # subtract beep duration (approx)

# Usage
# metronome(bpm=100, beats=8)

def main():
    metronome(bpm=120, beats=4)

if __name__ == "__main__":
    main()
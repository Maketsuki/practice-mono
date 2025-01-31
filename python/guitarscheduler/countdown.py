import time


def countdown(minutes, command_queue):
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
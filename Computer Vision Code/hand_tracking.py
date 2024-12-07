from cvzone.HandTrackingModule import HandDetector
import cv2
import socket

cap = cv2.VideoCapture(0)
cap.set(3, 854)
cap.set(4, 480)
success, img = cap.read()
h, w, _ = img.shape
detector = HandDetector(detectionCon=0.8, maxHands=2)

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)

def classify_gesture(lmList):
    # Landmark points for gesture classification
    thumb_tip = lmList[4]  # Now using full coordinate
    index_tip = lmList[8]
    middle_tip = lmList[12]
    ring_tip = lmList[16]
    pinky_tip = lmList[20]
    
    # Get y-coordinates for basic position checks
    thumb_y = thumb_tip[1]
    index_y = index_tip[1]
    middle_y = middle_tip[1]
    ring_y = ring_tip[1]
    pinky_y = pinky_tip[1]

    # Rock gesture: Thumb down and all other fingers extended
    if thumb_y < index_y and thumb_y < middle_y and thumb_y < ring_y and thumb_y < pinky_y:
        return "Rock"

    # Paper gesture: All fingers extended
    elif index_y < thumb_y and middle_y < thumb_y and ring_y < thumb_y and pinky_y < thumb_y:
        return "Paper"

    # Scissors gesture: Index and middle fingers extended, others folded
    elif (index_y < thumb_y and middle_y < thumb_y  # Index and middle extended
          and ring_y > middle_y and pinky_y > middle_y  # Ring and pinky folded
          and abs(index_y - middle_y) < 50):  # Index and middle roughly aligned
        return "Scissors"

    # Default to Unknown gesture
    return "Unknown"

while True:
    # Get image frame
    success, img = cap.read()
    # Find the hand and its landmarks
    hands, img = detector.findHands(img)  # with draw
    data = []

    if hands:
        # Hand 1
        hand = hands[0]
        lmList = hand["lmList"]  # List of 21 Landmark points
        
        # Classify the gesture
        gesture = classify_gesture(lmList)

        # Log the gesture to the terminal
        print(f"Current Gesture: {gesture}")

        # Collect landmark data and add gesture to it
        for lm in lmList:
            data.extend([lm[0], h - lm[1], lm[2]])  # Flip y-axis to match Unity

        # Add the gesture (Rock, Paper, Scissors) to the data
        data.append(gesture)

        # Send data (landmarks + gesture) over UDP
        sock.sendto(str.encode(str(data)), serverAddressPort)

    # Display
    cv2.imshow("Image", img)
    cv2.waitKey(1)

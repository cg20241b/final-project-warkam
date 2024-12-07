import socket
from cvzone.HandTrackingModule import HandDetector
import cv2

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
    thumb_tip = lmList[4][1]
    index_tip = lmList[8][1]
    middle_tip = lmList[12][1]
    ring_tip = lmList[16][1]
    pinky_tip = lmList[20][1]

    # Gesture classification logic
    if thumb_tip < index_tip and thumb_tip < middle_tip and thumb_tip < ring_tip and thumb_tip < pinky_tip:
        return "Rock"
    elif index_tip < thumb_tip and middle_tip < thumb_tip and ring_tip < thumb_tip and pinky_tip < thumb_tip:
        return "Paper"
    elif index_tip > thumb_tip and middle_tip > thumb_tip and ring_tip < thumb_tip and pinky_tip < thumb_tip:
        return "Scissors"
    else:
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

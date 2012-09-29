int pushButton = 2;
int previousState = 0;

void setup() {
  Serial.begin(9600);
  pinMode(pushButton, INPUT);
  pinMode(13, OUTPUT);
}

void loop() {
  int buttonState = digitalRead(pushButton);
  if (previousState != buttonState) {
    previousState = buttonState;
    if (buttonState == 1) {
      digitalWrite(13, HIGH);
      Serial.print("1");
    }
    else {
      digitalWrite(13, LOW);
      Serial.print("0");
    }
  }
}

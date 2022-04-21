add_library('sound')
import mic

angle = 0.0
offset = 400 # y-coord of each shape
scalar = 100 # boundaries for shape moving up and down; min and max
speed = 0.1
C1 = 0
c2 = 0
mult = 0


x = scalar
y = scalar

sound_level = 0



def setup():
    size(800, 800)
    background(0)
    mic.initialize(this, AudioIn, Amplitude)
    mic.sensitivity = 4.0


def draw():
  global offset, scalar, speed, angle, x_dim, y_dim, x, y
  background(0)
  sound_level = mic.get_level()
  mult = sound_level + 1
  
  # Shapes will start at offset and move on y coordinate 
  y1 = offset + sin(angle) * scalar * mult
  y2 = offset + sin(angle + 0.8) * scalar * mult      # add delay after angle to create wave-like animation
  y3 = offset + sin(angle + 1.6) * scalar * mult
  
  C1 = map(sound_level, 0.0, 1.5, 50, 255)
  C2 = map(y1, 300, 500, 0, 255)
  
  fill(C1, 150, 0, C1)
  ellipse(260, y1, 120, 120)
  
  fill(0, C1, 150, C1)
  ellipse(400, y2, 120, 120)
  
  fill(150, 0, C1, C1)
  ellipse(540, y3, 120, 120)
  angle += speed
  
  # testing
  # print(y1)
  # print(sound_level)

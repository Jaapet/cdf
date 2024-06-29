extends Camera2D

class_name ShakableCamera

var intensity = 1
var duration = 1
var start_time = 0
var rng = RandomNumberGenerator.new()


func _ready():
	randomize()
	set_process(false)
	
func _process(delta):
	var decreaser = (duration - (Time.get_ticks_msec() - start_time)) / duration
	
	var rand_x = rng.randf_range(-1, 1) * intensity * decreaser
	var rand_y = rng.randf_range(-1, 1) * intensity * decreaser
	
	offset = Vector2(rand_x, rand_y)
	
	if decreaser < 0:
		offset = Vector2.ZERO
		set_process(false)
	
func OnPlayerTakedDamage():
	shake_camera(5.0, 1.0)
		
func  shake_camera(_intensity = 1, _duration = 1):
	intensity = float(_intensity)
	duration = float(_duration * 1000)
	start_time = Time.get_ticks_msec()
	
	set_process(true)

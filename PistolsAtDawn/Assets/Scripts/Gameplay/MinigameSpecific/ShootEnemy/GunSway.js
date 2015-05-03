#pragma strict

var xSwayAmount : float = 0.01;
  var ySwayAmount : float = 0.05;
  var maxXamount : float = 0.35;
  var maxYamount : float = 0.2;
  
  private var vector3 : Vector3;
  
  var smooth : float = 3.0;
  function Start () {
  
          vector3 = transform.localPosition;
  
  }
  
  function Update () {
  
      var fx : float = -Input.GetAxis("Mouse X") * xSwayAmount;
      var fy : float = -Input.GetAxis("Mouse Y") * ySwayAmount;
      
          if(fx > maxXamount){
             fx = maxXamount;
          }
          if(fx < -maxXamount){
            fx = maxXamount;
          }
          if(fy > maxYamount){
             fy = maxYamount;
          }
          if(fy < -maxYamount){
            fy = -maxYamount;
          }
          
      var detection : Vector3 = new Vector3(vector3.x + fx, vector3.y + fy, vector3.x);
      transform.localPosition = Vector3.Lerp(transform.localPosition, detection, Time.deltaTime * smooth);
  
  }
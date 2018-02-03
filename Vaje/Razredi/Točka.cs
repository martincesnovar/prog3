public class Točka{
  private int x_;
  private int y_;
  public Točka(int kx, int ky){
      this.x_ = kx;
      this.y_ = ky;
  }
  
    public Točka(){
      this.x_ = 0;
      this.y_ = 0;
  }
  
  public int x { // lastnost x
      get { return x_; }
      set { this.x_ = value; }
  }

  public int y {
       get { return this.y_; }
       set { this.y_ = value; }
  }

  public override string ToString() {
     return "(" + this.x + "," + this.y + ")"
  }
}

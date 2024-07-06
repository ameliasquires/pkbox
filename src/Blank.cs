using Gtk;
class Blank : Box {
    public Blank(int width, int height) : base(Orientation.Horizontal, 0) {
        SetSizeRequest(width, height);
    }
}
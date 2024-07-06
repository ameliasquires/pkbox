using Gtk;
using PKHeX.Core;
public class PKMSlot : Button {
    public static int height = 56;
    public static int width = 68;
    public PKUISlot parent;
    public PKM pk;
    public Gdk.Pixbuf? pixbuf;
    public bool source;
    public int index;
    public TargetEntry [] target_table = new TargetEntry [] {
        new TargetEntry ("STRING", 0, 0 ),
        new TargetEntry ("text/plain", 0, 0),
        new TargetEntry ("application/x-rootwindow-drop", 0, 1)
	};
    static public string Img(PKM pk){
        string awa = ((Species)pk.Species).ToString().ToLower();
        return "pokesprite/pokemon-gen8/regular/" + awa + ".png";
    }
    public void DoDrag(){
        if(source){
            Gtk.Drag.SourceUnset(this);
            Gtk.Drag.SourceSet(this, Gdk.ModifierType.Button1Mask | Gdk.ModifierType.Button3Mask, target_table, Gdk.DragAction.Move);
            Gtk.Drag.SourceSetIconPixbuf(this, pixbuf);
            void beg(object o, DragBeginArgs args){
                //
                //Console.WriteLine("get " + this.index);
            }
            void drag_data(object o, DragDataGetArgs args){
                //use for cross-proc
                Console.WriteLine("get data " + this.index);
                //https://www.rabbitmq.com/tutorials/tutorial-six-dotnet
                //args.SelectionData.Set(args.SelectionData.Target, 8, System.Text.Encoding.UTF8.GetBytes());
                //args.Context.Data.Add("hi", "bye");
                //string[] aa = new string[1];
                //aa[0] = "hello";
                //args.SelectionData.SetUris(aa);
                //TreePath a = new TreePath();
                //args.SelectionData.Set(new Gdk.Atom(5), 5, new byte[5]);
                    //args.SelectionData.
            }
            //this.DragDataGet -= drag_data;
            //this.DragDataGet += drag_data;
            this.DragBegin -= beg;
            this.DragBegin += beg;
        }

        Gtk.Drag.DestUnset(this);
        Gtk.Drag.DestSet(this, DestDefaults.All, target_table, Gdk.DragAction.Move);
        
        void drop(object evm, DragDropArgs o){
            (Drag.GetSourceWidget(o.Context) as PKMSlot ?? throw new Exception("meow")).Swap(this);
            //this.Swap(Drag.GetSourceWidget(o.Context) as PKMSlot);
            //Console.WriteLine(o.Context.Data["hi"]);
            //PKMSlot p = new PKMSlot(o.)
            
        }
        void drop_data(object ev, DragDataReceivedArgs o){
            //Console.WriteLine(System.Text.Encoding.UTF8.GetString(o.SelectionData.Data));
            //Console.WriteLine(o.SelectionData.Uris[0]);
                //Console.WriteLine(((Image)(ev as Button).Child).Pixbuf.ByteLength);
                //im.Pixbuf = ((Image)(ev as Button).Child).Pixbuf;//new Gdk.Pixbuf("pokesprite/pokemon-gen8/shiny/" + ((Species)slot.save.PartyData[cop].Species).ToString().ToLower() + ".png");
                //((Image)(ev as Button).Child).Pixbuf = new Gdk.Pixbuf(shiny_file, 68, 56);
                //(Drag.GetSourceWidget(o.Context) as Button).Child.Destroy();
                //(Drag.GetSourceWidget(o.Context) as Button).Child = new Blank(68, 56);
                //(Drag.GetSourceWidget(o.Context) as Button).Child.Show();
                //((PKMSlot)ev).Swap(Drag.GetSourceWidget(o.Context) as PKMSlot);
                //Drag.GetData((Widget)ev, o.Context, o.Context.ListTargets()[0], o.Time);
                //((Image)(ev as Button ?? throw new Exception()).Child).Destroy();
        };
        //this.DragDataReceived -= drop_data;
        //this.DragDataReceived += drop_data;
        this.DragDrop -= drop;
        this.DragDrop += drop;
        
        
    }

    

    public PKMSlot(PKUISlot parent, PKM pk, int index) : base() {
        SetSizeRequest(width, height);
        this.WidthRequest = width;
        this.HeightRequest = height;
        this.parent = parent;
        this.pk = pk;
        this.index = index;
        this.Update(pk);
    }

    public void Update(PKM pk){
        this.pk = pk;
        if(this.source = (pk.Species != 0)) this.Child = new Image(this.pixbuf = new Gdk.Pixbuf(Img(pk), width, height));
        else this.Child = new Blank(width, height);
        DoDrag();
    }

    public void Swap(PKMSlot oper){
        this.parent.slot.Transfer(oper.parent.slot, this.index, this.parent.box_index, oper.index, oper.parent.box_index);
        this.parent.Update();
        oper.parent.Update();
    }
}
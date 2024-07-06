using Gtk;
public class PKUISlot : Grid {
    public bool party;
    public PKSlot slot;
    public int box_index;
    public int box_count => box_index < 0 ? 6 : this.slot.save.BoxSlotCount;

    public PKUISlot(PKSlot slot, int box_index) : base() {
        this.party = box_index < 0;
        this.slot = slot;
        this.box_index = box_index;
        this.Update();
        
    }
    public PKUISlot(PKSlot slot) : this(slot, -1) {}

    public int RowLen(){
        if(this.party) return 6;
        if(this.box_count % 6 == 0) return 6;
        if(this.box_count % 5 == 0) return 5;
        return 8;
    }
    public void Update(){
        for(;this.GetChildAt(0, 0) != null; this.RemoveRow(0));
        int row_brk = RowLen();
        
        PKMSlot ?last = null;
        for(int i, i2 = i = 0; i != this.box_count; i++, i2++){
            PKMSlot a = new PKMSlot(this, this.slot.Get(i, box_index), i);
            a.Margin = 2;
            a.MarginStart = a.MarginEnd = 1;
            if(row_brk == i2) {
                this.AttachNextTo(a, null, PositionType.Bottom, 80, 80);
                i2 = 0;
            } else this.AttachNextTo(a, last, PositionType.Right, 80, 80);
            
            last = a;
        }
        
        this.ShowAll();
        //this.Update(null, null);
        this.slot.Save("leafgreen.sav");
    }
}
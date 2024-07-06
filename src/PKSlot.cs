using System;
using System.IO;
using PKHeX.Core;
public class PKSlot {

    public SaveFile save;

    //pk5 is arbitrary
    public PKM BlankPKM = new PK3();
    public PKSlot(){
        this.save = new FakeSaveFile();
    }
     public PKSlot(String loc){
        this.save = (SaveFile)(FileUtil.GetSupportedFile(loc) ?? throw new Exception("Save file broken or not found"));
        this.BlankPKM = this.save.BlankPKM;
    }

    public PKSlot(SaveFile save){
        this.save = save;
        this.BlankPKM = this.save.BlankPKM;
    }

    virtual public void SetBox(PKM pkm, int box_index, int index) =>
        this.save.SetBoxSlotAtIndex(pkm, box_index, index);
    virtual public PKM GetBox(int box_index, int index){
        return this.save.GetBoxSlotAtIndex(box_index, index);
    }
    
    virtual public void SetParty(PKM pkm, int index){
        if(pkm.Species == 0) this.Remove(index, -1);
        else this.save.SetPartySlotAtIndex(pkm, index);
        this.FixShift();
    }
    virtual public PKM GetParty(int index){
        if(index > this.save.PartyCount) return this.BlankPKM;
        return this.save.GetPartySlotAtIndex(index);
    }

    public PKM Get(int index, int box_index){
      return box_index < 0 ? this.GetParty(index) : this.GetBox(box_index, index);
    }
    public void Set(PKM s, int index, int box_index){
      if(box_index < 0) this.SetParty(s, index);
      else this.SetBox(s, box_index, index);
    }

    public void FixShift(){
        for(int i = 6; i != -1; i--){
            if(this.GetParty(i).Species == 0) this.Remove(i, -1);
        }
    }

    public void Save(string loc){
        File.WriteAllBytes(loc, this.save.Write());
    }

    public void Remove(int index, int box_index){
        if(box_index<0) this.save.DeletePartySlot(index);
        else this.SetBox(BlankPKM, box_index, index);
    }

    public void Transfer(PKSlot dest, int src_index, int src_box_index, int dest_index, int dest_box_index, bool remove = true){
        PKM pokemon1 = this.Get(src_index, src_box_index);
        PKM pokemon2 = dest.Get(dest_index, dest_box_index);
        
        if(src_index > dest_index){
            dest.Set(pokemon1, dest_index, dest_box_index);
            this.Set(pokemon2, src_index, src_box_index);
        } else {
            this.Set(pokemon2, src_index, src_box_index);
            dest.Set(pokemon1, dest_index, dest_box_index);
        }
        
        /*if(src_box_index<0) pokemon1 = this.GetParty(src_index);
        else pokemon1 = this.GetBox(src_box_index, src_index);

        if(dest_box_index<0) dest.SetParty(pokemon, dest_index);
        else dest.SetBox(pokemon, dest_box_index, dest_index);*/

        //if(remove) this.Remove(src_index, src_box_index);

    }

    public string getImg(int index, int box_index){
        string awa = ((Species)this.Get(index, box_index).Species).ToString().ToLower();
        if(awa == "none") throw new Exception("blank slot");
        return "pokesprite/pokemon-gen8/regular/" + awa + ".png";
    }

}

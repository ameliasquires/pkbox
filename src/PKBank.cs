using System;
using PKHeX.Core;

public class PKBank : PKSlot {
    public const int BOX_SIZE = 40;
    public PKM?[] Box;

    public PKBank(){
        this.Box = new PKM?[BOX_SIZE];
    }

    override public void SetBox(PKM pk, int box_index, int index){
        if(index >= BOX_SIZE) throw new Exception("index larger than BOX_SIZE("+BOX_SIZE+")");

        int target = box_index * BOX_SIZE + index;

        if(target >= this.Box.Length){
            int next_box = BOX_SIZE * (int)Math.Ceiling((double)target / BOX_SIZE);
            if(next_box == target) next_box += BOX_SIZE;
            Array.Resize<PKM?>(ref this.Box, next_box);
            
        }

        this.Box[target] = pk.Species == 0 ? null : pk;
    }

    override public PKM GetBox(int box_index, int index){
        int target = box_index * BOX_SIZE + index;

        if(target >= this.Box.Length) return BlankPKM;

        return this.Box[target] ?? BlankPKM;
    }

    public void _print(){
        for(int i = 0; i != this.Box.Length; i++){
            if(i%BOX_SIZE == 0){
                Console.WriteLine("\n---- box "+i/BOX_SIZE);
            } 

            Console.Write((this.Box[i] ?? BlankPKM).Species.ToString() + ":");
            Console.Write((Species)(this.Box[i] ?? BlankPKM).Species);
            if((this.Box[i] ?? BlankPKM).IsShiny) Console.Write("*");
            Console.Write(" ");

        }
    }

    public override void SetParty(PKM pkm, int index) => throw new NotImplementedException();
    public override PKM GetParty(int index) => throw new NotImplementedException();
}
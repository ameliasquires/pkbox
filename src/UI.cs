using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using PKHeX.Core;
using System.Reflection;
using Gtk;

public class Awa
{

    public static void Main(string[] args) {
        
        Application.Init();

        Window window = new Window("meow");
        window.KeepAbove = true;
        

        PKSlot slot = new PKSlot("leafgreen.sav3");
        PKBank bank = new PKBank();
        /*for(int i = 0; i != 6; i++){
            //slot.getImg(i, -1);
            //string file = "pokesprite/pokemon-gen8/regular/" + ((Species)slot.save.PartyData[i].Species).ToString().ToLower() + ".png";
            //string shiny_file = "pokesprite/pokemon-gen8/shiny/" + ((Species)slot.save.PartyData[i].Species).ToString().ToLower() + ".png";
            //PKSlot_slot meow;
            //meow = new PKSlot_slot(slot, i, -1);
            PKMSlot meow = new PKMSlot(new(), slot.Get(i, -1));
		    //meow.DragDataReceived

            g.AttachNextTo(meow, null, PositionType.Right, 68, 56);
        }*/
        //DynamicGrid g = new DynamicGrid();
        //slot.Transfer(bank, 1, -1, 1, 1);
        //PKUISlot awa = new PKUISlot(slot);
        //PKUISlot bawa = new PKUISlot(bank, 1);
        
        //g.Add(awa);
        //g.Add(bawa);
        //g.Add(new PKMSlot(null, slot.GetParty(0), 5));
        //g.Add(new PKMSlot(null, slot.GetParty(1), 5));
        VBox vbox = new VBox(false, 1);
        //grid.Add();
        //g.Add(grid);
        PKUISlot top = new PKUISlot(slot);
        PKUISlot bottom = new PKUISlot(slot, 1);
        top.MarginBottom = bottom.MarginTop = 4;

        Separator seper = new Separator(Orientation.Horizontal);
        seper.HeightRequest = 2;

        vbox.PackStart(top, false, false, 0);
        vbox.PackStart(seper, false, false, 0);
        vbox.PackStart(bottom, false, false, 0);

        window.Add(vbox);
        //window.Add(g);

        //.Update();

         window.ShowAll();

        Application.Run();
        /*
        PKSlot bank = new PKBank();

        /*var a = FileUtil.GetSupportedFile("leafgreen.sav");
        if(a is null) return;
        SAV3 awa = (SAV3)(SaveFile)a;
        System.Console.WriteLine(awa.PlayTimeString);*/
        
        //PKSlot slot2 = new PKSlot("firered.sav");

        //slot2.save.SetPartySlotAtIndex(slot.save.PartyData[0], 3, PKMImportSetting.UseDefault, PKMImportSetting.UseDefault);

        /*foreach(PKM p in slot.save.PartyData){
            //Console.WriteLine(ind);
            slot.Transfer(slot2, ind, -1, ind, -1);

            Console.WriteLine(slot.save.PartyData[ind].Species.ToString());
            ind++;
            
        }*/
        /*
        for(int i = 0; i != 6; i++){
            PKM tmp = slot.save.GetPartySlotAtIndex(0);
            tmp.SetIsShiny(true);
            slot.save.SetPartySlotAtIndex(tmp, 0);
            slot.Transfer(bank, 0, -1, i, 4);
        }

        ((PKBank)bank)._print();

        for(int i = 0; i != 6; i++){
            bank.Transfer(slot, i, 4, i, -1);
        }

        ((PKBank)bank)._print();

        slot.Save("leafgreen.sav");
        /*for(int i = 0; i!=6; i++){
            slot.Transfer(slot, i, 2, i, -1);
        }

        foreach(PKM a in slot.save.BoxData){
            if(a.Species!=0)Console.WriteLine(a.Species);
        }*/
        
        //slot2.Save("firered.sav");
        //slot.Save("leafgreen.sav");
        /*var table = new Table();
        table.Title("Party");
        table.AddColumn("pokemon");
        table.HideHeaders();
        foreach(PKM pokemon in awa.PartyData){
            if(pokemon.Species == 0) continue;
            table.AddRow(pokemon.Species.ToString());

        }
            table.AddEmptyRow();
        AnsiConsole.Write(table);*/
    }
}

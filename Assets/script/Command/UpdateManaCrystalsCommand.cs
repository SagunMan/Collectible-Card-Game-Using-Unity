using UnityEngine;
using System.Collections;

public class UpdateResourceCommand : Command {

    private Player p;
    private int TotalMana;
    private int AvailableMana;

    public UpdateResourceCommand(Player p, int TotalMana, int AvailableMana)
    {
        this.p = p;
        this.TotalMana = TotalMana;
        this.AvailableMana = AvailableMana;
    }

    public override void StartCommandExecution()
    {
        p.PArea.ManaBar.TotalCrystals = TotalMana;
        p.PArea.ManaBar.AvailableCrystals = AvailableMana;
        CommandExecutionComplete();
    }
}

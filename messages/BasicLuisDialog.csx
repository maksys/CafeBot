using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
    public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"), Utils.GetAppSetting("LuisAPIKey"))))
    {
    }


    private const string RecurentOption = "Commande récurente";
    private const string SpecialOption = "Commande spéciale";

    [LuisIntent("")]
    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Vous avez-dit : {result.Query}. Vous souhaitiez certainement dir bonjour. Sinon je ne vous ai pas compris, tapez aide pour connaitre mes fonctionnalités"); //
        context.Wait(MessageReceived);
    }

    [LuisIntent("historique")]
    public async Task PurchaseRecords(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Souhaitez-vous connaitre tout votre historique de commande ?"); //
        context.Wait(MessageReceived);
    } 

    [LuisIntent("Aide")]
    public async Task HelpIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Je peux vous aider à commander du café, suivre votre livraison en cours, voire votre historique de commandes"); //
        context.Wait(MessageReceived);
    }
    [LuisIntent("suivi livraison")]
    public async Task ShipmentIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Votre colis est ici :"); //
        context.Wait(MessageReceived);
    }

    #region Order

    [LuisIntent("commander")]
    public async Task OrderIntent(IDialogContext context, LuisResult result)
    {
        //await context.PostAsync($"You have reached the order intent. You said: {result.Query}"); //
        //context.Wait(MessageReceived);
        this.ShowOptions(context);
    }

    private void ShowOptions(IDialogContext context)
    {
        PromptDialog.Choice(context, this.OnOrderOptionSelected, new List<string>() { RecurentOption, SpecialOption }, "Souhaitez-vous déclencher votre commande réccurente ou passer une nouvelle commande?", "Cette option est invalide", 3);
    }

    private async Task OnOrderOptionSelected(IDialogContext context, IAwaitable<string> result)
    {
        try
        {
            string optionSelected = await result;

            switch (optionSelected)
            {
                case RecurentOption:
                    //context.Call(new RecurentOrderDialog(), this.ResumeAfterOptionDialog);
                    break;

                case SpecialOption:
                    //context.Call(new SpecialOrderDialog(), this.ResumeAfterOptionDialog);
                    break;
            }
        }
        catch (TooManyAttemptsException ex)
        {
            await context.PostAsync($"Ooops! trop de tentatives :( Mais ne vous inquiétez pas je gère cette erreur et vous allez pouvoir recommancer.");

            //context.Wait(this.MessageReceivedAsync);
        }
    }
    #endregion


}
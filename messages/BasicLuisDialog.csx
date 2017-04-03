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

    [LuisIntent("")]
    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the none intent. You said: {result.Query}"); //
        context.Wait(MessageReceived);
    }

    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("historique")]
    public async Task PurchaseRecords(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the previous pruchase records intent. You said: {result.Query}"); //
        context.Wait(MessageReceived);
    } 
    [LuisIntent("commander")]
    public async Task OrderIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the order intent. You said: {result.Query}"); //
        context.Wait(MessageReceived);
    }
    [LuisIntent("Aide")]
    public async Task HelpIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the help intent. You said: {result.Query}"); //
        context.Wait(MessageReceived);
    }
    [LuisIntent("suivi livraison")]
    public async Task ShipmentIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the shipment intent. You said: {result.Query}"); //
        context.Wait(MessageReceived);
    }
}
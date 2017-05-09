using System;
using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;

public class MainDialog : IDialog<object>
{
	public MainDialog()
	{

	}
    public Task StartAsync(IDialogContext context)
    {
        context.Wait(MessageReceivedAsync);
        return Task.CompletedTask;
    }
    public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        var message = await argument;
        await context.PostAsync($"Bonjour {message.From.Name}");
        //context.Call(BasicForm.BuildFormDialog(FormOptions.PromptInStart), FormComplete);
    }
}

using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

[Serializable]
public class RecurentOrderDialog : IDialog<object>
{
	public RecurentOrderDialog()
	{
	}
}

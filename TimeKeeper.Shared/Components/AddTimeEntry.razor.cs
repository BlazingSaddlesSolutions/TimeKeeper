﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TimeKeeper.Shared.Api;
using TimeKeeper.Shared.Api.Features.TimeEntry;

namespace TimeKeeper.Shared.Components
{
    public partial class AddTimeEntry
    {
        [Inject] protected ITimeEntryApi TimeEntryApi { get; set; }

        [Parameter] public EventCallback<string> OnClick { get; set; }

        protected CreateTimeEntry.Command Command { get; set; }

        protected override void OnParametersSet()
        {
            //TODO this will be replaced with actual user id once authentication has been implemented.
            var userId = 1;

            Command = new CreateTimeEntry.Command
            {
                UserId = userId
            };
        }

        protected async Task HandleValidSubmit()
        {
            await TimeEntryApi.Create(Command);
            await OnClick.InvokeAsync("SubmitTimeEntry");
        }

        protected async Task CancelAsync()
        {
            await OnClick.InvokeAsync("CancelTimeEntry");
        }
    }
}
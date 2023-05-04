namespace Orchid.App
{
    [Activity(Name = "Activities.MainActivity", Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        #region Protected Methods

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }

        #endregion Protected Methods
    }
}

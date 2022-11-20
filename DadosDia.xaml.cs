namespace Projeto_Agenda;

public partial class DadosDia : ContentPage
{
	public DadosDia()
	{
		InitializeComponent();
	}

    private void TemaPadrao(object sender, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            Application.Current.UserAppTheme = AppTheme.Light;
        }

    }

    private void TemaEscuro(object sender, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
        }

    }
}
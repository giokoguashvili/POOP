public class Application {
    private UserInterface _ui;
    public Application(UserInterface ui){
        this._ui = ui;
    }
    public void Run() {
        while (ui.RetrieveCommand()) {
            this._ui.ExecuteCommand();
        }
    }
}
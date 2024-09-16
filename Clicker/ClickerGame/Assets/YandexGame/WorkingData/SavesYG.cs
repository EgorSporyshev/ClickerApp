
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        //public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        public int money = Variables.money;
        public int TimesClicked = Variables.TimesClicked;
        public int click_value = Variables.click_value;

        public bool upgrade_1 = Variables.upgrade_1;
        public bool upgrade_2 = Variables.upgrade_2;
        public bool upgrade_3 = Variables.upgrade_3;

        public bool achievement_1 = Variables.achievement_1;
        public bool achievement_2 = Variables.achievement_2;
        public bool achievement_3 = Variables.achievement_3;

        // ...

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            //openLevels[1] = true;
        }
    }
}

using QuizApp.App.Common;
using QuizApp.Domain.Entity;

namespace QuizApp.App.Concrete;

public class MenuActionService : BaseService<MenuAction>
{
    public MenuActionService()
    {
        Initialize();
    }
    public List<MenuAction> GetMenuActionsByMenuName(string menuName)
    {
        List<MenuAction> result = new List<MenuAction>();
        foreach (var menuAction in Items)
        {
            if (menuAction.MenuName == menuName)
            {
                result.Add(menuAction);
            }
        }
        return result;
    }

    private void Initialize()
    {
       
    }
}
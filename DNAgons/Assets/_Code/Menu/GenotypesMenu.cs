using UnityEngine;
using UnityEngine.UI;

public class GenotypesMenu : MonoBehaviour {

    public GameObject dnagonButtonPrefab;
    public Transform contentPagePanel;
    public ObjectPool buttonObjectPool;
    public Text paginationDisplay;

    [SerializeField]
    int currentPage = 1;
    Pager paginationObj;

    public int selectedItemIndex;
    public DNAgonButton SelectedButton { get; set; }

    //private ModalWindow modalWindow;
    //void Awake () { modalWindow = ModalWindow.Instance(); }

    void Start ()
    {
        //ResetGenotypesMenu();
        paginationObj = new Pager(XMLManager.Ins.genotypeDB.list.Count, currentPage);
        AddButtons(paginationObj.StartIndex, paginationObj.EndIndex);
        UpdatePaginationText();
    }

    void OnEnable()
    {
        ResetGenotypesMenu();
    }

    void ResetGenotypesMenu()
    {
        currentPage = 1;
        SelectedButton = null;
        paginationObj = new Pager(XMLManager.Ins.genotypeDB.list.Count, currentPage);
        AddButtons(paginationObj.StartIndex, paginationObj.EndIndex);
        UpdatePaginationText();
    }

    void AddButtons(int startIndex, int endIndex)
    {
        foreach (Transform child in contentPagePanel.transform)
        {
            buttonObjectPool.ReturnObject(child.gameObject);
        }

        for (int i = startIndex; i < endIndex; i++)
        {
            DNAgon _dnagonGenotype = XMLManager.Ins.genotypeDB.list[i];
            GameObject _newButton = buttonObjectPool.GetObject();
            _newButton.transform.SetParent(contentPagePanel);

            DNAgonButton _dnagonGenotypeButton = _newButton.GetComponent<DNAgonButton>();
            _dnagonGenotypeButton.SetupMenu(this);
            _dnagonGenotypeButton.SetupDNAgon(_dnagonGenotype);
        }
    }
    
    public void GoToNextPage ()
    {
        currentPage++;
        if (currentPage > paginationObj.TotalPages)
            currentPage = paginationObj.TotalPages;

        UpdatePageButtons();
    }

    public void GoToPrevPage ()
    {
        currentPage--;
        if (currentPage <= 0)
            currentPage = 1;

        UpdatePageButtons();
    }

    void UpdatePageButtons ()
    {
        SelectedButton = null;
        paginationObj = new Pager(XMLManager.Ins.genotypeDB.list.Count, currentPage);
        AddButtons(paginationObj.StartIndex, paginationObj.EndIndex);
        UpdatePaginationText();
    }

    void UpdatePaginationText()
    {
        paginationDisplay.text = paginationObj.CurrentPage + " / " + paginationObj.TotalPages;
    }

    public void DNAgonGeneticProfile ()
    {
        Debug.Log("Display DNAgon Genetic Profile Info.");
    }
}

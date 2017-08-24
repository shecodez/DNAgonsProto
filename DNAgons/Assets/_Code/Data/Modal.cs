using UnityEngine;

public class Modal {

    //public string title;
    public string question;
    public Sprite iconImg;
    public Sprite panelBackgroundImg;
    public ModalType mType;

    public ModalButton modalButton1;
    public ModalButton modalButton2;
    public ModalButton modalButton3;
}

public enum ModalType
{
    Info,
    Warning,
    Danger
};

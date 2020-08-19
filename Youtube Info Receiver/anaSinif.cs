namespace Youtube_Info_Receiver
{
    public abstract class anaSinif
    {
        public abstract void URL_Ayarla(string url);
        public abstract string IsimCek();
        public abstract string SureCek();
        public abstract string ThumbnailCek();
        public abstract string AciklamaCek();
        public abstract double LikeCek();
        public abstract double DisslikeCek();
        public abstract int IzlenmeCek();
        public abstract string KanalCek();
    }
}
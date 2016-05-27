namespace UserVoiceSystem.Services.Web.Common
{
    public interface IIdentifierProvider
    {
        int DecodeId(string urlId);

        string EncodeId(int id);

        int DecodeIdTitle(string urlIdTitle);

        string EncodeIdTitle(int id, string title);
    }
}

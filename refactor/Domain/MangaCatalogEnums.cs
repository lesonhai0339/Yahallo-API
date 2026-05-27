namespace YAHALLO.Domain.Enums.MangaEnums;

public enum MangaPublicationState
{
    Draft = 1,
    Published = 2,
    Locked = 3,
    Deleted = 4
}

public enum MangaPublicationDemographic
{
    Unknown = 0,
    Shounen = 1,
    Shoujo = 2,
    Seinen = 3,
    Josei = 4
}

public enum MangaContentRating
{
    Safe = 1,
    Suggestive = 2,
    Erotica = 3,
    Pornographic = 4
}

public enum MangaRelationType
{
    Monochrome = 1,
    MainStory = 2,
    AdaptedFrom = 3,
    BasedOn = 4,
    Prequel = 5,
    SideStory = 6,
    Doujinshi = 7,
    SameFranchise = 8,
    SharedUniverse = 9,
    Sequel = 10,
    SpinOff = 11,
    AlternateStory = 12,
    AlternateVersion = 13,
    Preserialization = 14,
    Serialization = 15
}

public enum MangaLinkType
{
    OfficialRaw = 1,
    OfficialEnglish = 2,
    AniList = 3,
    AnimePlanet = 4,
    BookWalker = 5,
    MangaUpdates = 6,
    NovelUpdates = 7,
    MyAnimeList = 8,
    Kitsu = 9,
    Amazon = 10,
    EBookJapan = 11,
    CDJapan = 12,
    Raw = 13,
    EnglishTranslation = 14,
    Other = 99
}

public enum UserMangaReadingStatus
{
    Reading = 1,
    OnHold = 2,
    PlanToRead = 3,
    Dropped = 4,
    ReReading = 5,
    Completed = 6
}


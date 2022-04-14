export interface IPlayer {
    club: string,
    country: string,
    height: number,
    id: number,
    isLegend: boolean,
    league: string,
    name: string,
    salary: number,
    surname: string,
    weight: number,
    level: number,
    position: string,
    rarity: string,
    picturePath: string,
}

export interface IUser {
    id: string,
    stadium: IStadium,
    userSponsor: IUserSponsor,
    userDetail: IUserDetail,
    name: string,
    password: string,
    email: string,
    clubName: string,
    country: string,
    birthDate: Date,
    money: number,
    profilePicturePath: string,
    isPlaying: boolean,
    isInQueue: boolean,
    isAccepted: boolean,
    notifications: INotification[]
    usersPlayers: IUsersPlayer[],
    usersItems: IUsersItems[],
    userMatchesHistory: IUserMatchesHistory[],
    expenses: IExpenses[],
}

export interface IStadium {
    id: number,
    name: string,
    price: number,
    incomePerViewer: number,
    seatsCapacity: number,
    level: number,
}

export interface ISponsor {
    id: number,
    name: string,
    matchPrize: number,
    winPrize: number,
    titlePrize: number,
    requiredLevel: number,
}

export interface IUserSponsor {
    id: number,
    sponsor: ISponsor,
    matchPrizeCount: number,
    matchPrizeTotality:number,
    winPrizeCount: number,
    winPrizeTotality: number,
    titlePrizeCount: number,
    titlePrizeTotality: number,
}

export interface IUserDetail {
    id: number,
    rankPoints: number,
    matchesPlayed: number,
    matchesWon: number,
    matchesDrawn: number,
    matchesLost: number,
    lastSeasonRank: string,
    allMatchesPlayed: number,
    allMatchesWon: number,
    allMatchesDrawn: number,
    allMatchesLost: number,
}

export interface IUsersPlayer {
    id: number,
    player: IPlayer,
    user: IUser,
    usersPlayerPoints: IUsersPlayerPoints,
    usersPlayerState: IUsersPlayerState,
    level: number,
    experience: number,
    requiredExperience: number,
    condition: number,
    contract: number,
    salary: number,
    score: number,
    trainingType: string,
}

export interface IUsersPlayerState {
    id: number,
    isCaptain: boolean,
    isOnAuction: boolean,
    isPlaying: boolean,
    isOnBench: boolean,
    isInjured: boolean,
    isBoosted: boolean,
}

export interface IUsersPlayerPoints {
    id: number,
    onePoints: number,
    twoPoints: number,
    threePoints: number,
    allOnePoints: number,
    allTwoPoints: number,
    allThreePoints: number,
}

export interface IUserMatchesHistory {
    id: number,
    userId: string,
    user2Id: string,
    userClub: string,
    user2Club: string,
    userScore: number,
    user2Score: number,
    mvp: string,
    mvpScore: number,
    isDone: boolean,
    matchDate: Date,
}

export interface IUsersItems {
    id: number,
    item: IItem,
    count: number,
}

export interface IItem {
    id: number,
    name: string,
    iconPath: string,
    price: number,
    description: string,
}

export interface IAuction {
    id: number,
    userId: string,
    usersPlayer: IUsersPlayer,
    price: number,
    bid: number,
}

export interface INotification {
    id: number,
    receiver: string,
    topic: string,
    content: string,
    createDate: Date,
    iconPath: string,
    isRead: boolean,
}

export interface IExpenses {
    id: number,
    itemName: string,
    transactionDate: Date,
    count: number,
    value: string,
    iconPath: string,
}

export interface IRankRequirements {
    id: number,
    rankName: string,
    pointsRequired: number,
    pointsLimit: number,
    iconPath: string,
}

export interface IBackgroundTask {
    id: number,
    userId: string,
    user2Id: string,
    jobId: string,
    taskName: string,
    isStarted: boolean,
}
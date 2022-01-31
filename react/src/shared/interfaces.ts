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
    weight: number
}

export interface IUser {
    id: string,
    stadium: IStadium,
    sponsor: ISponsor,
    userDetail: IUserDetail,
    name: string,
    password: string,
    email: string,
    clubName: string,
    country: string,
    birthDate: Date,
    money: number,
    profilePicturePath: string,
    notifications: INotification[]
    usersPlayers: IUsersPlayer[],
    usersItems: IUsersItems[],
    userMatchesHistory: IUserMatchesHistory[],
}

export interface IStadium {
    id: number,
    name: string,
    price: string,
    incomePerViewer: number,
    seatsCapacity: number,
}

export interface ISponsor {
    id: number,
    name: string,
    matchPrize: number,
    winPrize: number,
    titlePrize: number,
}

export interface IUserDetail {
    id: number,
    rankPoints: number,
    matchesPlayed: number,
    matchesWon: number,
    matchesDrawn: number,
    matchesLost: number,
}

export interface IUsersPlayer {
    id: number,
    player: IPlayer,
    auction: IAuction,
    level: number,
    condition: number,
    salary: number,
    isCaptain: boolean,
    isOnAuction: boolean,
}

export interface IUserMatchesHistory {
    id: number,
    userClub: string,
    opponentClub: string,
    userScore: number,
    opponentScore: number,
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
}

export interface IAuction {
    id: number,
    name: string,
    surname: string,
    country: string,
    club: string,
    league: string,
    weight: number,
    height: number,
    level: number,
    condition: number,
    salary: number,
    price: number,
    bid: number,
}

export interface INotification {
    id: number,
    receiver: string,
    topic: string,
    content: string,
}
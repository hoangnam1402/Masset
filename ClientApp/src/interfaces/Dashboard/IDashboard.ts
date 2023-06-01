export default interface IDashboard {
    totalAsset: number,
    totalComponent:number,
    totalMaintenance:number,
    totalEmployee:number,
    numberOfStatus1:number,
    numberOfStatus2:number,
    numberOfStatus3:number,
    numberOfStatus4:number,
    numberOfStatus5:number,
    numberOfStatus6:number,
    numberOfTypes:NumberOfType[]
}

interface NumberOfType {
    name: string,
    count: number
}
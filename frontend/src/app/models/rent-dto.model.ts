export interface RentDTO {
    id: number;

    idCustomer: number;
    name: string;

    idCar: number;
    model: string;
    brand: string;

    day: string;
    dayRemaining: string;

    idPayTypeName: number;
    payTypeName:string;

    idPrice: number;
    price: number;
}
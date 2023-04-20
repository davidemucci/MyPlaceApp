export interface Reservation {
  reservationCode: string;
  date: Date;
  office: Office;
  officeId: number;
  user: User;
  userId: number;
}

export interface Building {
  id: number;
  name: string;
  address: string;
  floorsNumber: number;
  offices: Office[];
}

export interface Office {
  id: number;
  name: string;
  floor: number;
  maxCapacity: number;
  buildingId: number;
  building: Building;
  reservations: Reservation[];
}

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  password: string;
  reservations: Reservation[];
}

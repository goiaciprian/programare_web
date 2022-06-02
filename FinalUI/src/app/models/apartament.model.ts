import { User } from './user.model.ts';

export interface Apartament {
  iD_Apartament: number;
  adresa: string;
  chirie: number;
  createdAt: Date;
  proprietar: User;
}

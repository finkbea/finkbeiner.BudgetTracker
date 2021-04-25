import {Income} from './incomes';
import {Expenditure} from './expenditures';

export interface UserDetails {
    id: number;
    email: string;
    fullname: string;
    joinedOn: Date;
    incomes: Income[];
    expenditures: Expenditure[];
}
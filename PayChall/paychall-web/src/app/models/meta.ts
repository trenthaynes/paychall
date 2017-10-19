import { Discount } from './discount';
import { Cost } from './cost';

export class Meta {
  payPeriods: number;
  basePay: number;
  costs: Cost[];
  discounts: Discount[];
}

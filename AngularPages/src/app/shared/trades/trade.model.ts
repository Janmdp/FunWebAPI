import { Shift } from '../shifts/shift.model';
import { User } from '../users/user.model';

export class Trade {
    TradeId: number;
    Shift: Shift;
    ReworkShift: Shift;
    RequestUser: User;
    AcceptUser: User;
    ShiftId: number;
    ReworkShiftId: number;
    RequestUserId: number;
    AcceptUserId: number;
}

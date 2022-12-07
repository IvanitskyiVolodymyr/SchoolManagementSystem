import { Token } from "@angular/compiler";
import { User } from "../Users/user";

export interface AuthUser {
    user: User;
    tokens: Token;
}
import { User } from "../Users/user";
import { Token } from "./token";

export interface AuthUser {
    user: User;
    tokens: Token;
}
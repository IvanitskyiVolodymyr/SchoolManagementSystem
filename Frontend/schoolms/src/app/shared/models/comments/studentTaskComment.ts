import { ShortUserInfo } from "../Users/shortUserInfo";

export interface StudentTaskComment {
    studentTaskCommentId: number;
    commentParentId: number | undefined;
    comment: string;
    createdAt: Date;
    updatedAt: Date;
    shortUserInfo: ShortUserInfo;
}
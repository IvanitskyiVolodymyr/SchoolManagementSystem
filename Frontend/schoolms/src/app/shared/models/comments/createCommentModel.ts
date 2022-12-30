export interface CreateCommentModel {
    studentTaskId: number;
    commentParentId: number | undefined;
    comment: string;
    userId: number;
}
export interface UserSubject {
    id: string;
    ownerId: string;
    name: string;
    privat: boolean;
    description: string;
    photoBase64: string;
    records?: any;
}
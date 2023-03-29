export const getFormatDateTime = (date: Date) => {
    const DATE_OPTIONS = {
      day: "2-digit",
      month: "2-digit",
      year: "numeric",
    } as const;

    return new Date(date).toLocaleDateString("vi-VN", DATE_OPTIONS);
  };
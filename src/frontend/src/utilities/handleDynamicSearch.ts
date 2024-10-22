export const handleDynamicSearch = (oldArray: any[], newArray: any[]): any => {
  const array = oldArray.concat(newArray);
  // remove duplicated object with same item.id and empty objects
  const uniqueArray = array.filter((item, index, self) => {
    return item.id && self.findIndex((t) => t.id === item.id) === index;
  });
  return uniqueArray.concat(uniqueArray[0]);
};

export const handleNextPage = (array: any[], lastPage: boolean): any => {
  const uniqueArray = array.filter((item, index, self) => {
    return item.id && self.findIndex((t) => t.id === item.id) === index;
  });
  if (lastPage) {
    return uniqueArray;
  } else {
    return uniqueArray.concat(uniqueArray[0]);
  }
};

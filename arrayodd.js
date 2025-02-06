let sum=0;
const odd =[1,2,3]
let length= odd.length;
console.log(length);
for(let i in odd)
{
    sum=sum+odd[i];
}
sum=sum-odd[(length-1)/2];
console.log(sum);
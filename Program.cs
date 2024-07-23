//*****************************************************************************
//** 1636. Sort Array by Increasing Frequency leetcode                       **
//** Poor code with a hash that takes a lot of time.        -Dan             **
//*****************************************************************************


/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
int* frequencySort(int* nums, int numsSize, int* returnSize) {
    int *retnum = (int*)malloc(numsSize * sizeof(int*));
    int hash[201];
    int min = 202;
    int max = 0;
    int countMax = 0;
    for(int i = 0; i < numsSize; i++)
    {
        if((nums[i]+100) > max) max = nums[i]+100;
        if((nums[i]+100) < min) min = nums[i]+100;
        hash[(nums[i]+100)]++;
        if(hash[(nums[i]+100)] > countMax) countMax = hash[(nums[i]+100)];
    }
//    for(int i = min; i < max+1; i++)
//        printf("hash[%d] = %d\n",i-100,hash[i]);

    int current = 1;
    int coco = 0;
    for(int i = 0; i < numsSize; i++)
    {
        for(int j = max; j >= min; j--)
        {
            if(hash[j]==current) 
            {
                while(hash[j]>0)
                {
                    retnum[coco++] = j-100;
                    hash[j]--;
                }
            }
        }
        current++;
    }

//    for(int i = 0; i < numsSize; i++)
//        printf("retnum[%d] = %d\n",i,retnum[i]);
//    printf("current = %d",current);

    *returnSize = current-1;
    return retnum;
}
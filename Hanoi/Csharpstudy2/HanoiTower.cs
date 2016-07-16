using System;

public class HanoiTower
{
    private readonly int maxDisks;
    public int[] Disks { get; private set; }
    public int DiskCount
    {
        private set;
        get;
    }
    public HanoiTower(int maxDisks)
    {
        this.maxDisks = maxDisks;
        Disks = new int[maxDisks];  
    }
    public void InsertAllDisks()//처음 시작할 때 한 타워에 모든 디스크 끼워놓기
    {
        for(int i = 0; i < maxDisks; i++)
        {
            Disks[i] = maxDisks - i;
        }
        DiskCount = maxDisks;
    }
    public void InsertDisk(int disk)
    {
        Disks[DiskCount]=disk;
        DiskCount++;
    }
    public int RemoveDisk()
    {
        int disk=Disks[DiskCount-1];
        Disks[DiskCount-1] = 0;
        DiskCount--;
        return disk;
    }
}

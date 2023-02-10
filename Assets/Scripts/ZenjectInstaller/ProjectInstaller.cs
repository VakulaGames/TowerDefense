using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private Sound _soundPrefab;

    public override void InstallBindings()
    {
        BindGameData();
        BindSound();
    }

    private void BindSound()
    {
        Container
                    .Bind<Sound>()
                    .FromComponentInNewPrefab(_soundPrefab)
                    .AsSingle()
                    .NonLazy();
    }

    private void BindGameData()
    {
        GameData gameData = new GameData( 8, 2);

        Container
                    .Bind<GameData>()
                    .FromInstance(gameData)
                    .AsSingle()
                    .NonLazy();
    }


}

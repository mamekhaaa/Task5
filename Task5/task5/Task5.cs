using System;
using System.Collections.Generic;

public interface IFilm
{
    string Название { get; set; }
    void Воспроизвести();
    void Остановить();
}

public abstract class ОтечественныйФильм : IFilm
{
    public string Название { get; set; }
    public int Год { get; set; }

    public abstract void Воспроизвести();

    public void Остановить()
    {
        Console.WriteLine("Фильм остановлен.");
    }

    public void ПоказатьИнформацию()
    {
        Console.WriteLine($"Название: {Название}, Год выпуска: {Год}");
    }
}

public class Комедия : ОтечественныйФильм
{
    public string ОсновнойАктер { get; set; }
    public string Режиссер { get; set; }

    public override void Воспроизвести()
    {
        Console.WriteLine($"Воспроизведение комедии: {Название}");
    }

    public void СделатьШутку()
    {
        Console.WriteLine("Создание шуток...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<IFilm> фильмы = СоздатьФильмы();
        ВоспроизвестиФильмы(фильмы);

        Комедия конкретнаяКомедия = ПолучитьКонкретнуюКомедию(фильмы);
        ВызватьМетодКомедии(конкретнаяКомедия);

        Console.ReadLine();
    }

    static List<IFilm> СоздатьФильмы()
    {
        List<IFilm> фильмы = new List<IFilm>();

        Комедия комедия = new Комедия
        {
            Название = "Ирония судьбы, или С лёгким паром!",
            Год = 1975,
            ОсновнойАктер = "Андрей Миронов",
            Режиссер = "Эльдар Рязанов"
        };
        фильмы.Add(комедия);

        return фильмы;
    }

    static void ВоспроизвестиФильмы(List<IFilm> фильмы)
    {
        foreach (var фильм in фильмы)
        {
            фильм.Воспроизвести();
            фильм.Остановить();
        }
    }

    static Комедия ПолучитьКонкретнуюКомедию(List<IFilm> фильмы)
    {
        Комедия конкретнаяКомедия = null;

        foreach (var фильм in фильмы)
        {
            if (фильм is Комедия комедия)
            {
                конкретнаяКомедия = комедия;
                break;
            }
        }

        return конкретнаяКомедия;
    }

    static void ВызватьМетодКомедии(Комедия комедия)
    {
        if (комедия != null)
        {
            комедия.СделатьШутку();
        }
    }
}
